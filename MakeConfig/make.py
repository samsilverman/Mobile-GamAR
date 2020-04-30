import sys, os


dir = sys.argv[1]
out = sys.argv[2]
subs = "Mobile GamAR/Assets/Resources/"
name = dir.replace(subs, "")

outfile = open("Mobile GamAR/Assets/StreamingAssets/" + out, "w")
files = os.listdir(dir)
count = 0
for i, f in enumerate(files):
  if f[-7:] == ".prefab":
    count += 1
  else:
    continue
  if count >= 100:
    break
  outfile.write("{} {}/{}\n".format(count, name, f.replace(".prefab", "")))
