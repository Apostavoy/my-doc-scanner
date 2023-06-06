"""
MyDoc Scanner Server

page.py

{Desc}

Author: Paul McAvoy & Nikola Apostolov
Date Updated: 04/06/2023
"""

import pytesseract
from PIL import Image
from pageText import PageText


class Page:
    """
    Page Class

    pageData: JPEGImage Object
    """
    def __init__(self, pageData):
        self.imgData = pageData

    def get(self):
        return self.imgData

    def crop_page(self, x1, y1, x2, y2):
        return Page(self.imgData.crop(x1, y1, x2, y2))

    def extract_text(self):
        return PageText(pytesseract.image_to_string(self.imgData))
