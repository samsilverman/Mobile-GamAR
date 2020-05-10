import sys, os, glob
from PIL import Image
import numpy as np


def imread(fp):
    return np.asarray(Image.open(open(fp, "rb")))

def imwrite(fp, x):
    return Image.fromarray(x).save(open(fp, "wb"))


img = imread("poker_source.jpg")
print(img.shape)
nonwhite = img.sum(2) < 700
rows = np.where(nonwhite.sum(1))[0]
cols = np.where(nonwhite.sum(0))[0]
heights = 1 + np.where(((rows[1:] - rows[:-1]) - 1) != 0)[0]
widths = 1 + np.where(((cols[1:] - cols[:-1]) - 1) != 0)[0]

newimg = img.copy()
for h in heights:
    newimg[h] = 0
for w in widths:
    newimg[:, w] = 0
imwrite("temp.png", newimg)