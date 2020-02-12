#!/bin/bash

echo "first run"

gmcs second.cs 
./second.exe < inputfile
rm second.exe
echo "first run done"




