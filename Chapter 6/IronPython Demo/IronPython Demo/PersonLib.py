import clr
clr.AddReference("Business")

from Business import *

class PersonLib:
	def getPerson(self):
		p=Person()
		p.Name = "Filip"
		return p