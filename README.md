# ImageProcessor

The ImageProcessor application is a simple image manipulation API that accepts an image file and can transform the image by a combinations of commands.

This API uses a HTTP Post request to transmit user commands. The commands are strings that have been compiled into a List, then parsed to perform the manipulations.

## Commands

Here are the available commands with their string input:

- Flip horizontal = *"flip h"*
- Flip vertical = *"flip v"*
- Rotate +/- n degrees = *"rotate ###"* where ### is a number in degrees
- Rotate left = *"rotate ccw"*
- Rotate right = *"rotate cw"*
- Convert to fixed grayscale = *"convert end"*
- Convert to a user-specified grayscale = *"convert ##"* where ## is a floating point number
- Saturate = *"saturate"*
- Desaturate = *"dull"*
- Resize (x, y) = *"resize XX YY"* where XX is the horizontal value, and YY is the vertical value
- Resize percentage = *"resize %"* where % is the percentage value
- Generate a thumbnail = *"thumb"*

Commands entered via POST must be separated by a ";" in the entry body in order to be parsed correctly.

**Example Command Entry:** *"dull; rotate 15; thumb"*
