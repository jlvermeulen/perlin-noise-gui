A GUI for creating Perlin noise.

---
##Noise Settings

###Intensity
This value controls the colours in the layer will be close to the Shadow or Highlight colour. All values generated by the noise algorithm will be multiplied by this value.

Range: [0.00, 100.00]  
Default: 1.00

###Levels
This value controls how many levels of detail will be generated for this layer. From the base level specified by Offset, it will generate noise with arrays repeatedly doubled in size and add the result to the previously generated noise.

Range: [1, 10]  
Default: 1  
Notes: Levels + Offset can never exceed 11, as this detail is too small to be rendered even at the largest image size.

###Offset
This value controls the base level of detail.

Range: [1, 10]  
Default: 0  
Notes: Levels + Offset can never exceed 11, as this detail is too small to be rendered even at the largest image size.

###Range Handling
This value controls how the noise algorithm will handle range conversions. The algorithm generates values in the range [-1, 1], and then uses the specified method to convert it to [0, 1].

The effects of the different options are as follows:
- Absolute: take the absolute value
- Clamp: all negative values will become 0
- InverseAbsolute: take 1 minus the absolute value
- None: perform no conversion
- Shift: add 1 and divide by 2

Allowed values: Absolute, Clamp, InverseAbsolute, None, Shift  
Default: Shift

###Wrap
When checked, colours with values greater than the Highlight colour wrap back around to the Shadow colour. When unchecked, colours are clamped between the Highlight and Shadow colour.

Default: Unchecked

###Per channel
When checked, RGB channels are allowed to wrap individually, even if other channels are not wrapping. When unchecked, all channels wrap at the same time.

Default: Unchecked  
Notes: Only available when Wrap is checked.

###Shadow
When the noise value for a pixel is 0, it will have the colour represented by the RGB values entered here.

Range: [0, 255] for each channel  
Default: 0

###Highlight
When the noise value for a pixel is 1, it will have the colour represented by the RGB values entered here.

Range: [0, 255] for each channel  
Default: 255