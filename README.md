# QRCodeGenerator
Windows application to generate QR codes (intended for URLs)
1. Download QRCodeGenerator.zip file here: https://github.com/mcnods/QRCodeGenerator/raw/main/QRCodeGenerator.zip
2. Extract it on your Windows workstation
3. Run the Setup.exe file to get the QR Code Generator to run.

If you're feeling generous, you can venmo me: https://venmo.com/MC-Martinez

General User Notes:
1. This will only work on a Windows computer, not Mac, Linux, etc.
2. The max text input length is 2083 characters which is currently the max length of a URL supported in modern broswers.
3. The only file output to save is a Bitmap/.bmp file type. If you need/want another file type, please do so in an image editor such as MS Paint, Paint.Net, Inkscape, Photoshop, etc.
4. The file dimensions are 500x500 pixels. If you need/want to resize it, please do so in an image editor such as MS Paint, Paint.Net, Inkscape, Photoshop, etc.
5. If you share a computer and there are multiple logins on that workstation, each person will need to install the app to use it.
6. You do not need an internet connection to use this application.
7. Nothing you do is stored or shared besides the images you save directly to your computer which are 100% in your control.
8. Feel free to share this with friends, family, frenemies or even foes.

Technical Notes:
1. I coded this in C#/XAML.
2. I used Visual Studio 2019 on a Windows 10 workstation.
3. This is a ClickOnce application and it is installed per Windows User (so if this is a computer you log into that other people *also* log into, you will each need to install it). https://en.wikipedia.org/wiki/ClickOnce
4. I used Zxing to do the actual QR Code generation: https://github.com/zxing/zxing
5. I'm an admittedly poor programmer, so don't flame me.
6. If you have any technical advice for someone who does not enjoy programming in general, be kind (and please rewind).
7. All I really did was give Zxing a couple of buttons, text input box and image display + a save prompt.
8. If you're a remotely capable programmer or interested in it, this is a very simple project - if I can do it, you can, too. Seriously, I hate writing code.
