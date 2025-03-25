# Old code with side effects
# settings = {
#     'volume': 70,
#     'brightness': 50
# }
# def adjust_brightness(level):
#     settings['brightness'] = level
#     print("Brightness set to:", settings['brightness'])

# New code without side effects
def adjust_brightness(settings, level):
    new_settings = settings.copy()
    new_settings['brightness'] = level
    print("Brightness set to:", new_settings['brightness'])
    return new_settings

settings = {'volume': 70, 'brightness': 50}
settings = adjust_brightness(settings, 80)