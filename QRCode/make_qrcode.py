import qrcode
for i in range(100):
  img = qrcode.make(f"MG{i:03d}.ptn").convert("RGB")
  img.save(open(f"qrcodes/{i:03d}.png", "wb"))
