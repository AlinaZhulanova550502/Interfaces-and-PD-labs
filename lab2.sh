#! /bin/bash
sudo hdparm -i /dev/sda | grep Model
sudo hdparm -i /dev/sda | grep Drive | cut -f 1,3 -d ':'
sudo hdparm -i /dev/sda | grep 'PIO modes'
sudo hdparm -i /dev/sda | grep ' DMA modes'
echo "Total space: "
sudo parted -l | awk 'NR==2' | cut -f 3 -d ' '
df | awk '{_used += $3; _free += $4} END {print "used: " _used/1024/1024 "GB free: " _free/1024/1024 "GB"}'

