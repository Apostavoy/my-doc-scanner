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

    data: JPEGImage Object
    """
    def __init__(self, pageData):
        self.imgData = pageData

    def get(self):
        return self.data

    def crop_img(self, x1, y1, x2, y2):
        return Page(self.imgData.crop(x1, y1, x2, y2))

    def read_img(self):
        return PageText(pytesseract.image_to_string(self.imgData))
