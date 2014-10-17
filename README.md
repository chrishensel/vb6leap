vb6leap
=======

An effort to ease maintenance, development and migration of legacy VB6-code where it is not possible to modernize it rapidly without too much effort.

This project aims to mainly aid maintaining VB6 legacy code. It is **NOT** intended to revive VB6 or encourage developers to start new projects with that language!
VB6 has been discontinued and it seems that it will never ever be open-sourced by Microsoft or otherwise be made available free-of-charge, sadly.

History
=======

Even though Microsoft and their MVPs sort-of live in their own worlds and pretend that VB6 is dead and gone, it is everything *but*! It certainly is anything but **gone**! ;-)
There is a giant/humongous/ridiculously large amount of code in businesses around the world that is still written in VB6 and it most definitely won't go away in the next years!

Personally, I think that VB6 itself isn't too bad of a language. The syntax is clear and it has a certain beauty to it.
Aside from its obvious flaws such as COM and a [nowadays] crappy, unstable IDE that doesn't run too well on Windows Vista and above and has many flaws you sure all know.

You may feel free to disagree. But you cannot disagree on the fact that VB is still in widespread use and even continues to live on as VBA in MS Office.

There are some projects on the internet that try to provide users with an alternative to VB6 IDE, but most of them are commercial and cost money. I wanted to change that.

The name "vb6leap" is called like that because actually I couldn't think of a better name and I needed one for GitHub. That's the only explanation.

Disclaimer
==========

I have a few things to say that you should carry in mind. Those may contain sarcasm or exaggerations.

1. This is my spare-spare time project, that I work on when I have got spare time in my spare time. This means that it will not be updated too often, however...
2. ... you may feel free to contribute anything (features, fixes) to this project, by using pull requests.
3. You are responsible for any damage that this project may cause to your VB6 projects and files. It's 2014, by now you should have most of your stuff under version control.
4. There are definitely bugs in this project, I won't deny that. Also see #2.
5. The code may contain stuff that is undone. Well, this is also due to #1.
6. The code docmentation may be lacking. Will be fixed as I go.

Building it
===========

The code should compile a 100% with SharpDevelop. So if you don't want to use Visual Studio, feel free to give that project a try!

**Precondition:** You need to have SharpDevelop installed or have to download the portable version, because the SharpDevelop-Add-In requires some assemblies from there.
You can find SharpDevelop here: http://www.icsharpcode.net/OpenSource/SD/Download/

I recommend you to download the portable version, so you won't need an installation.

Please see https://github.com/icsharpcode/SharpDevelop/wiki/AddIn-Developer-Quick-Start-Guide for how to setup SharpDevelop for add-in development.

First you need to build the main solution. Just build "\VB6leap\vb6leap.sln".

In order to build the *vb6leap add-in*, you have to perform the following steps:
1. Download SharpDevelop, as mentioned
2. Create a new folder called "Build" inside the "\AddIns\SharpDevelop" directory (next to the solution file)
3. Copy the "ICSharpCode.*.dll" files into that directory
4. Open the add-in solution and build it.