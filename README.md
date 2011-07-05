Syntan
======

It generates LR parser tables from formal grammatics, and demonstrates the parsing mechanism on an input symbol.

This was a university project of mine. This software is intended for education, not for production.

This software is free (as in speach and beer). It uses the GNU General Public License v3.0 (see gpl-3.0.txt).

The ui language is currently hungarien.


Platform
--------

I originally developed on Windows and for .NET Framework 4. But should run on Mono too. I intend to make sure, it runs ok on Mono and linux too.


Usage
-----

There is no installer - yet. You must compile it from source.

The syntan.dll is a library, which contains the core functionality.

The Demo application is the educational tool.


Roadmap
-------

Planed for the next weeks:
* Add a detailed todo.txt
* Unit testing and code coverage 
* Make it Mono/Linux compatible
* documentation

Later:
* Make the Demo app translatable
* Provide a default english translation
* Save/Load parsing sessions
* LR(1), LALR(1) parser table builders
* WPF Demo app
* Show the parser table generation details
