import qrcode, os


os.system("mkdir imgs")
for i in range(100):
  img = qrcode.make(f"MG{i:03d}.ptn").convert("RGB")
  img.save(open(f"imgs/{i:03d}.png", "wb"))
