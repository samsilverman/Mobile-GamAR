import sys, os, glob
from PIL import Image
import numpy as np
import matplotlib.pyplot as plt

def imread(fp):
    return np.asarray(Image.open(open(fp, "rb"))).astype("int32")

def imwrite(fp, x):
    return Image.fromarray(x.astype("uint8")).save(open(fp, "wb"))

idir = sys.argv[1]
pdir = sys.argv[2]
odir = sys.argv[3]
pics = glob.glob(f"{idir}/*.png") + glob.glob(f"{idir}/*.jpg")
ptns = glob.glob(f"{pdir}/*.png") + glob.glob(f"{pdir}/*.jpg")
pics.sort()
ptns.sort()

CARD_WIDTH = 280
CARD_HEIGHT = 448
PAD = 20
large = np.zeros((CARD_HEIGHT * 4 + 5 * PAD, CARD_WIDTH * 13 + 14 * PAD, 3))
for i in range(len(pics)):
    #pic = imread(pics[i])
    pic = Image.open(open(pics[i], "rb"))
    w, h = pic.size
    pic = pic.resize((CARD_WIDTH, CARD_HEIGHT), Image.BICUBIC)
    pic = np.array(pic)
    h, w = pic.shape[:2]
    stx = w // 3
    size = 2 * w // 3
    ptn = Image.open(open(ptns[i], "rb"))
    w, h = ptn.size
    if h < w:
        ptn = ptn.resize((int(h * float(size) / w), size), Image.BILINEAR)
    else:
        ptn = ptn.resize((size, int(w * float(size) / h)), Image.BILINEAR)
    ptn = np.array(ptn)
    pic[:ptn.shape[0], stx : stx + size] = ptn
    stx = PAD + (PAD + CARD_HEIGHT) * (i // 13)
    sty = PAD + (PAD + CARD_WIDTH) * (i % 13)
    large[stx:stx+CARD_HEIGHT, sty:sty+CARD_WIDTH] = pic
    imwrite(f"{odir}/{i:02d}.png", pic)
    print(i)
imwrite(f"large.png", large)