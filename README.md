# Certificate-Password-Recovery
Brute Force password recovery for exported Windows PFX certificates

Originally developed and CopyRighted by Rion Carter, 2012. The only thing I added was exit logging and settings restore if the application exited before finding the password, and updated the core base for .Net 4.5.2 (Windows 7 and higher).

Find his original release here:
https://boredwookie.net/blog/m/certificate-password-recovery-tool

>In a previous article I mentioned that I'd be Open sourcing a Password recovery app that I had put together to help me remember by Blackberry Codesigning Certificate password. This post is the "Homepage" for the utility and will describe what it is and how to use it.
>
>Read on for details (Download link is at the bottom of the page)
>
>This Certificate Password Recovery tool is released under an Open Source (MIT) License. As I discussed in a previous article, this tool has helped me recover my Blackberry Code signing certificate password. The intent of this tool is to help developers recover passwords in situations where they have forgotton or lost the password, yet still remember certain pieces or characteristics of the pass string.
>
>The utility is not intended for illegal or unscrupulous purposes.
>
>**System Requirements**
>
>1. ~~Microsoft .NET 4.0 Client Profile~~ Microsoft .NET 4.5.2
>2. 15MB of Available RAM
>3. ~~Visual Studio Express 2010 (If you want to build the solution)~~ Visual Studio 2015 Community
>
>**Performance Notes** 
>
>*System 1: Core i3 Laptop (2011)*
>
>- Core i3-2330M CPU (Clocked @ 2.2GHz)
>- 8GB DDR3 RAM (4GB + 4GB)
>- Dual Channel @ 667MHz
>- 9-9-9-24 Timing
>- 1:5 ratio (FSB:DRAM)
>- Command Rate: 1T
>- Performance: 36 to 41 Million Password tries per day
>
>*System 2: HP Desktop (2012)*
>
>- AMD FX-6100 CPU (Clocked @ 3.3GHz)
>- 6GB DDR3 RAM (4GB + 2GB)
>- Dual Channel @ 667MHz
>- 9-9-9-24-33 Timing (33 is Bank Cycle Time)
>- 3:10 ratio (FSB:DRAM)
>- Command Rate: Not Specified
>- Performance: 44 million password tries per day
>
>*System 3: Dell Optiplex GX620 (2005)*
>
>- Intel Pentium 4 521 CPU (Clocked @ 2.8GHz)
>- 1GB DDR2 RAM (4x 256MB)
>- Dual Channel @ 266MHz
>- 4-4-4-12-16 (16 is Bank Cycle Time)
>- 3:4 ratio (FSB:DRAM)
>- Command Rate: Not Specified
>- Performance: 27 million password tries per day
>
>The Utility is single-threaded. For maximum effectiveness in recovering your password I recommend:
>
>1. Use what you remember of the password
>In my case I could remember the beginning and end of my password string. This reduced what I had to guess from 13 characters down to 6
>
>2. Center the password recover tool's attempts around the most likely password "area"
>For example, if you are trying to find a password like 'p@ssword!' DON'T just start the brute-force at 'a' and let it increment (b,c,d......aaab,aaac,aaad,etc...). Start the recovery utility at something like 'paaaaaaa'
>**Note**: Be sure to account for the fat finger! You may think you have a 13 character password but it could be only 12 characters or it could be 14 or 15 characters long. To play it safe, you might want to start it off one character shorter than you are expecting...
>
>3. Reduce the character set
>If you KNOW that certain symbols, letters or numbers are NOT present in the password be sure to remove them from the brute force character sequence
>For example, I was able to cut my character set down from 76 to 23. This improved my cracking ability enough to make it worthwhile to use the cracker tool.
> 
>4. Run multiple instances of the Utility (Up to 1 per core) trying different scenarios
>Have one instance start with a prefix
>Have another instance start with a suffix
>If you have more cores, you could try staggered steps
>
>**How to use the Utility**
>Open the EXE found in CertificatePasswordRecovery\CertificatePasswordRecovery\bin\Release
>
>While it looks like there are a lot of options, they are all explained below
>
>**Configure the Settings:**
>Max Generated Characters specifies how many characters you want to generate. It will go from 1 character up to (and including) the maximum specified here
> 
>Starting String lets you decide where you want to start your generated password. For example: If you enter aaa in this field then your sequence will go aaa,aab,aac,etc...
> 
>Prefix String is useful in cases where you remember the first few characters of your password. No need to waste time 'guessing' those if you already know them. For example if you know that your password starts with pass, enter 'pass' in the prefix box.
> 
>Suffix String is helpful when you remember the last few characters of your password. 
> 
>In the Symbol Sequence box you can specify a comma-separated list of characters you want to be present in the password search. It can be arbitrarily ordered.
>
**>Note**: For reliable results, leave the space at the beginning of the symbol sequence!
>Note 2: The more characters you can remove from this list, the quicker your search will go.
>
>Path To Cert lets you pick the keystore or certificate you want to use when guessing passwords
>
>Path to Log File lets you pick the path to the logfile where attempts are logged
>
>**Note**: The utility will crash if given a non-existant folder path. It will create the txt file automatically, but not the folder structure up to it.
> 
>Log Level lets you pick how to log. Explanation of settings:
>Off will not log anything. Be careful with this setting: It means the only notification you'll receive is a pop-up dialog when the password is found. Nothing is written out to disk
> 
>Success Only will log the start of the process, then write the password out to the file when it is found. All non-valid passwords are ignored
> 
>Every 10,000 + Success will log every 10,000th password along with the Succesful password. This is useful if you want to track the progess of the password guessing.
>
>**Note**: Don't open the file directly. Instead, copy it then open. Otherwise the file could be locked when the Utility tries to write-out
> 
>Everything will log every password attempt to the log file. This is the Slowest setting as writing to disk is fairly slow. Use this option if you want to find out what password combinations are being tested.
 >
>The Help / about link will take you to this page
> 
>
>**Notes about the Recovery tool**:
>It Will not find spaces at the beginning or end of a password unless manually entered in the prefix / suffix boxes
> 
>To specify a comma as a sequence symbol you must enter 'comma' (without the quote marks). This is becuase I split the string on comma and need another way to represent that character
> 
>If characters are entered in the 'starting string' box that are not present in the symbol sequence, you will be alerted. This could negatively affect the pasword search
> 
>A space is the first character in the default sequence. This allows the password cracker to easily handle passwords that are up to the max length, while not starting at the max length
>Note: For best results it is highly recommended to leave the space as the first character in the sequence!
>
>
>Download
>Download the Certificate Password Recovery Tool
>
>**Note**: Antivirus software may not like this tool even though it has legitimate uses. For best results, build the source code using Visual C# 2010 Express (microsoft.com). This will give you the opportunity to inspect & improve upon the code.
