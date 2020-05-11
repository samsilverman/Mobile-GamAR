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

for i in range(len(idir)):
    #pic = imread(pics[i])
    pic = Image.open(open(pics[i], "rb"))
    w, h = pic.size
    pic = pic.resize((h * 2, w * 2), Image.BICUBIC)
    pic = np.array(pic)
    h, w = pic.shape[:2]
    size = stx = w // 2
    ptn = Image.open(open(ptns[i], "rb"))
    w, h = ptn.size
    if h < w:
        ptn = ptn.resize((int(h * float(size) / w), size), Image.BILINEAR)
    else:
        ptn = ptn.resize((size, int(w * float(size) / h)), Image.BILINEAR)
    ptn = np.array(ptn)
    pic[:ptn.shape[0], size : size * 2] = ptn
    imwrite("temp.png", pic)
    break
