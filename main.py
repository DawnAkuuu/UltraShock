from pishock import PiShockAPI
import time, os

username = "" # PiShock username
api_key = "" # PiShock api key
sharecode = "" # Shock module share code

api = PiShockAPI(username, api_key)

shocker = api.shocker(sharecode)

last_modified = 0
path = r"{PATH}"

while True:
    try:
        mod_time = os.path.getmtime(path)
        if mod_time != last_modified:
            last_modified = mod_time
            with open(path, "r") as f:
                print("Event:", f.read())
            shocker.beep(duration=1)
            time.sleep(1)
            shocker.shock(duration=1, intensity=20) # Change the duration and intensity of the shock here.

    except FileNotFoundError:
        pass
    time.sleep(0.5)  # Check every 0.5 seconds
