import unittest
import requests

class MyTestCase(unittest.TestCase):
    def test_something(self):
        jsonD = {
            "fileData": self.readFileData().decode('latin-1')
        }

        requests.post("http://localhost:5000/api/pdfupload", json=jsonD)

    def readFileData(self):
        with open(".test_data/testPDF.pdf", "br") as bytePDF:
            return bytePDF.read()


if __name__ == '__main__':
    unittest.main()
