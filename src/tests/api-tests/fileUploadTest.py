"""
MyDoc Scanner Server Unit Tests

fileUploadTest.py

Document Upload Testing

Author: Paul McAvoy & Nikola Apostolov
Date Updated: 04/06/2023
"""

import unittest
import requests


class TestFileUpload(unittest.TestCase):
    def test_standardPDFUpload(self):
        with open("test-files/testPDF.pdf", "rb") as file:
            fileDict = {
               "file": ("testPDF.pdf", file)
            }
            response = requests.post("http://localhost:5000/pdfupload", files=fileDict)

        self.assertTrue(response.json()["uploaded"])


if __name__ == '__main__':
    unittest.main()
