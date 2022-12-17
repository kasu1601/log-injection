/* README */

This is a vulnerable C# web application where the user input from the login form is not properly santitzed.
Each login attempt will be recorded in a log file -- in this case i have added it to the console for the ease
of testing.

An attacker can send a post request to the application where the username parameter will be replaced with
a malicious string of script or just simple false information line which will then be fed to the log file.
The attacker has to know the input style of the log file to cover their traces well. Once this pattern is known,
the attacker can then enter false entries and go under the radar without raising any suspicions

The commented line of code is where the user input sanitization takes place, where I strip all \r and \n in user
input to replace them with a whitespace.