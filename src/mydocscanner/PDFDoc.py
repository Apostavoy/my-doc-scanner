"""
MyDoc Scanner

PDFDoc.py

{Desc}

Author: Paul McAvoy & Nikola Apostolov
Date Updated: 04/06/2023
"""

import pdf2image
from pdf2image import convert_from_path
from Page import Page


class PDFDoc:
    """
    PDFDoc Class

    path: path to PDF file.
    pages: collection of Page objects.
    """
    def __init__(self, path):
        self.path = path
        self.pages = self.extract_pages()

    def extract_pages(self):
        return [Page(p) for p in convert_from_path(self.path)]

    def __getitem__(self, index):
        return self.pages[index]

    def __repr__(self):
        return ''