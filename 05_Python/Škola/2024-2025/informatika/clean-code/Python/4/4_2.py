settings = {
    'volume': 70,
    'brightness': 50
}

def adjust_brightness(level):
    settings['brightness'] = level
    print("Brightness set to:", settings['brightness'])

adjust_brightness(80)
