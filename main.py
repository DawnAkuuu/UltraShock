from pishock import PiShockAPI
import time, os
from pathlib import Path

username = "" # PiShock username
api_key = "" # PiShock api key
sharecode = "" # Shock module share code

api = PiShockAPI(username, api_key)
shocker = api.shocker(sharecode)

homeDir = Path.home()

last_modified = 0
path = f"{homeDir}" + r"\AppData\LocalLow\Hakita\ULTRAKILL\ultrakill_event.txt"

while True:
    try:
        mod_time = os.path.getmtime(path)
        if mod_time != last_modified:
            last_modified = mod_time
            with open(path, "r") as f:
                print("Event:", f.read())
            shocker.beep(duration=1)
            time.sleep(1)
            shocker.shock(duration=1, intensity=20)

    except FileNotFoundError:
        pass
    time.sleep(0.5)  # Check every 0.5 seconds
