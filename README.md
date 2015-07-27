#Keyboard Spectrograph for Corsair RGB series keyboards and mice.

#Summary
This application is made to run in the place of the Corsair Utility Engine. It provides several effects that are not available through CUE, such as a spectrograph for audio playing through the computer or from input devices, randomized lighting, reactive lighting effects, idle/away timer with profile switching, and other features. It is still in active development, and there are many new features on the way!

#Installation
Please ensure that you are running .NET 4.5+. You can download it <a href="http://www.microsoft.com/en-ca/download/details.aspx?id=30653">here</a>.
Download the compiled binaries from <a href="http://emily-maxwell.com/?page=keyboardspectro">my website</a>, and extract them to a location of your choice.

#Usage
When you launch the program for the first time, it will open up to the Settings tab. Here, you should select the keyboard model that you're using, and then which layout you're using. To the right of this, you can select which mouse you're using as well, and have the effects extend to it. (Note that Spectro doesn't extend to the mouse yet, only the stuff on the Effects tab)

With your keyboard and mouse selected, click on the Spectro tab. Select what you want your foreground and background colours to be (foreground is on top, background is on the bottom), and then choose your audio source. If you select Output, it'll capture whatever is being played through your system's default output device. Select input to use a microphone, line-in, or other input device for capture instead.

Hit Start, and play some music!

If you find that it's not picking up your audio very well, try turning up the sensitivity. If you want to slow down or speed up the effects, change the Refresh Delay (my personal favourite is a value of 10).

#Upcoming Features
Reactive Typing
Heatmap
Mouse heat lighting
STRAFE support
Windows audio device mute state observation (to toggle the mute button's colour)
Rework of rendering engine

#Known Issues
- AMD HDMI Audio drivers don't play nicely with, well, anything. It's possible that you'll have issues if that's your default output device.
- Spectro background effects can stop when there is no audio stream. This is due to WASAPI closing the stream. This will be corrected with the engine rework.

#More Info
Check out the main forum thread at http://forum.corsair.com/v3/showthread.php?t=139027
Changelog and other information: http://emily-maxwell.com/

#License
This project is licensed under the GNU GPL v3.0.

#Cheers!
I hope you enjoy using this program as much as I enjoy making it!