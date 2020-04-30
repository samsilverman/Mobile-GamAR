import time
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

import os

# Get images to upload
img_dir = 'qrcodes'
paths = os.listdir(img_dir)
paths = [i for i in paths if os.path.splitext(i)[1] in [".jpg", ".png"]]
abspaths = [os.path.abspath(img_dir + os.sep + p) for p in paths]

try:
    vuforia_user = os.environ['VUFORIA_USER']
    vuforia_pass = os.environ['VUFORIA_PASS']
    vuforia_database = os.environ['VUFORIA_DATABASE']
except KeyError as e:
    print("It seems the VUFORIA_USER or VUFORIA_PASS or VUFORIA_DATABASE are not correctly set in the environment")
    print("Please set them by using")
    print("export VUFORIA_USER=YOUR_EMAIL_ADDRESS")
    print("export VUFORIA_PASS=YOUR_PASSWORD")
    print("export VUFORIA_DATABASE=YOUR_DATABASE_NAME")
    quit()

driver = webdriver.Chrome()

# Utils
getid = driver.find_element_by_id

# Login page
driver.get('https://developer.vuforia.com/vui/auth/login');
time.sleep(1)

in_login = getid("login_email")
in_pass = getid("login_password")
btn_login = getid("login")

in_login.send_keys(vuforia_user)
in_pass.send_keys(vuforia_pass)
btn_login.click()

# Go to Vuforia Target Manager page
print("=> Wait to click target manager")
wait = WebDriverWait(driver, 30)
print("=> Try to click")
btn_target_manager = wait.until(EC.element_to_be_clickable((By.ID, 'targetManager')))
btn_target_manager.click()

# Go to selected database
print("=> Go to selected database")
#btn_database = wait.until(EC.element_to_be_clickable((By.XPATH, '//span[text()="{0}"][1]/parent::a'.format(vuforia_database))))
btn_database = wait.until(EC.element_to_be_clickable((By.XPATH, "//span[text()='{0}'][1]".format(vuforia_database))))
btn_database.click()

for absp in abspaths:
    time.sleep(1)
    wait.until(EC.invisibility_of_element_located((By.ID, 'uploadTargetModal')))

    btn_add_target = wait.until(EC.element_to_be_clickable((By.ID, 'addDeviceTargetUserView')))
    btn_add_target.click()

    btn_add_image = wait.until(EC.presence_of_element_located((By.ID, 'targetImgFile')))
    btn_add_image.send_keys(absp)

    in_dim = getid("targetDimension")
    in_dim.send_keys("1")

    # Target name is set automatically, modify here if you want to set something different than filename
    #in_name = getid("targetName")
    #in_name.send_keys(os.path.splitext(absp)[0].split(os.sep)[-1]) # img name without extension

    getid("AddDeviceTargetBtn").click()

time.sleep(5)
