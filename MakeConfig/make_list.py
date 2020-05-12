import sys, os, glob


pdir  = sys.argv[1]
idir = sys.argv[2]
adir = sys.argv[3]
out = sys.argv[4]
subs = "Mobile GamAR/Assets/Resources/"

outfile = open("Mobile GamAR/Assets/StreamingAssets/" + out, "w")
files = glob.glob(pdir + "/*.prefab") # prefabs
files.sort()

imgs = glob.glob(idir + "/*.png") + glob.glob(idir + "/*.jpg")
imgs.sort()

prints = glob.glob(adir + "/*.png") + glob.glob(adir + "/*.jpg")

count = 0
for i in range(max(len(files), len(imgs))):
  if i > 50: break
  prefab = files[i % len(files)].replace(".prefab", "").replace(subs, "")
  img = imgs[i % len(imgs)]
  outfile.write("{} {} {}\n".format(i, prefab, img))
