# UltraShock
An Ultrakill mod that connects to the PiShock shock collar that shocks you when you die.


### The mod
The mod works by checking your health whenever the GetHurt() method is called. If your HP is zero, it will write to a file on your machine in documents. 

This file is then read by the python script which will check for modifications to the file. If python detects a modification, it will administer a shock through the PiShock library.

## PiShock Info:
https://pishock.com/

## PiShock API Info: 
https://docs.pishock.com/pishock/api-documentation/%E2%9A%A1-api-documentation-index.html

## How to install the mod:

As of this moment, I am unsure where a good place to put the changing file into that works for everyones systems but for now you can compile the project yourself.

If you want to know how to compile the project, there is a tutorial here that teaches you how to create your own mod. Just follow it and dump the source code in main.cs into that file and follow the rest of the tutorial as normal.

https://www.youtube.com/watch?v=fL4koeLJ4ko

### Make sure you change the file directories in both the main.cs file and the main.py file
