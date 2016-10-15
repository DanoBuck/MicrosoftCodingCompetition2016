import json
from pprint import pprint

def isCorrupted(line):
	lastChar = 0
	for c in line:

		if not ((ord(c) > 47 and ord(c) < 58) or (ord(c) > 64 and ord(c) < 71) or ord(c) == 92 or ord(c) == 10):
			return True

		if lastChar == 92 and ord(c) == 92:
			return True
		if ord(c) == 92:
			lastChar = 92
		if ord(c) != 92:
			lastChar = 0
	return False

def decodeAllCaps(line):
	listOfCompression = "0123456789ABCDEF"
	nextValueHex = False
	nextValueToEncode = False
	decodedLine = ""
	repeats = 0
	for c in line:
		if nextValueToEncode:
			for i in range(repeats):
				decodedLine += c
			nextValueToEncode = False
		elif nextValueHex:
			nextValueHex = False
			nextValueToEncode = True
			repeats = listOfCompression.find(c) + 3

		elif c == '\\':
			nextValueHex = True
		else:
			decodedLine += c
	return decodedLine

with open('input.txt') as f1:
	content1 = f1.readlines()

	for line in content1:
		if(isCorrupted(line)):
			print("CORRUPTED", end="\n")
		else:
			print(decodeAllCaps(line), end="")