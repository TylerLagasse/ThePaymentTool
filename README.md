# ThePaymentTool
A payment tool that will read, parse, and convert ACH and WIRE files into readable file formats, such as JSON and XML.
# ACH FILES SUPPORTED:
CCD, CTX, PPD, WEB, TEL, IAT. All Addenda supported.
# WIRE FILES
Partial WIRE2JSON file support has been added 5/15/2020. The WIRE files use the BAI2 format specification.    
The currently supported Funds Type are 0, 1, 2, S, V, Z, and D.  
There are if null checks put in place now to make sure the temporary fields for S and V are not inserted into Fund Types such as 0 to 1, or even each other.  
  
The other headers are in place with Exception catches in the optional fields.  
