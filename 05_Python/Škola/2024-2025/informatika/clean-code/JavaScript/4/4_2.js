let settings = {
  volume: 70,
  brightness: 50
};

function adjustBrightness(level) {
  settings.brightness = level;
  console.log("Brightness set to: " + settings.brightness);
}

adjustBrightness(80);
