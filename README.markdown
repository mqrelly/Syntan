Syntan
======

It generates LR parser tables from formal grammatics, and demonstrates the parsing mechanism on an input symbol.

This was a university project of mine. This software is intended for education, not for production.

This software is free (as in speach and beer). It uses the GNU General Public License v3.0 (see LICENSE.txt).

The ui language is currently hungarien.


Platform
--------

I originally developed on Windows and for .NET Framework 4.
I intend to make sure, it runs ok on Mono and linux too.


Usage
-----

There is no installer - yet. You must compile it from source.

The syntan.dll is a library, which contains the core functionality.

The Demo application is the educational tool.


Unit tests and code coverage tools
----------------------------------

For the unit tests [xUnit](http://xunit.codeplex.com/) is used. And
for code coverage I use [PartCover](http://sourceforge.net/projects/partcover/)
and [ReportGenerator](http://www.palmmedia.de/) on Windows.

If You want to use them, there are scripts (dos batch files) in
`tools/` directory. You must make the following files, by copiing and
editing the templates (in the same directory). If a tool is not in the
path, it must be prepended with absolute path in it's batch script.
I.e. for xUnit the content of `tools/xunit-console.bat` is:

    C:\Programs\xUnit\xunit.console.clr4.exe %*


These scripts can then be called from anywhere, i.e. as a *Post-Build*
event.


Tool dependecies:

- xUnit >= v1.7 beta
- PartCover >= 2.3.3403
- ReportGenerator >= 0.7.2.0


Roadmap
-------

Planed for the not-to-distant future:

- Documentation

Later:

- Replace the paltform specific Glee graph layout lib.
- Make the Demo crosscompile on Linux/Mono
- Make the Demo app translatable
- Provide a default english translation
- Save/Load parsing sessions
- LR(1), LALR(1) parser table builders
- WPF Demo app
- Show the parser table generation details


Contact
-------

My name is Márk Szabadkai. I'm the aouthor and sole maintainer of
this project. You can contact me at mqrelly@gmail.com .
