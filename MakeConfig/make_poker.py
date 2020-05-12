import sys, os, glob
from PIL import Image
import numpy as np
import matplotlib.pyplot as plt

def imread(fp):
    return np.asarray(Image.open(open(fp, "rb"))).astype("int32")

def imwrite(fp, x):
    return Image.fromarray(x.astype("uint8")).save(open(fp, "wb"))


img = imread("poker_source.jpg")
print(img.shape)
nonwhite = img.sum(2) < 765
rows = np.where(nonwhite.sum(1) > 10)[0]
cols = np.where(nonwhite.sum(0) > 10)[0]
#heights = np.where(((rows[1:] - rows[:-1]) - 1) != 0)[0]
#widths = np.where(((cols[1:] - cols[:-1]) - 1) != 0)[0]

newimg = img.copy()
N_rows = 13
N_cols = 4
PAD = 10
sr = (img.shape[0] - 2 * PAD) // N_rows
sn = (img.shape[1] - 2 * PAD) // N_cols

os.system("mkdir pics")
count = 0
for i in range(N_rows):
    h = PAD + sr * i
    for j in range(N_cols):
        w = PAD + sn * j
        imwrite(
            f"pics/{count:02d}.png",
            img[h:h+sr, w:w+sn].copy())
        count += 1