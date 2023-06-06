"""
MyDoc Scanner Server

pdfDoc.py

{Desc}

Author: Paul McAvoy & Nikola Apostolov
Date Updated: 04/06/2023
"""
import os
import shutil

from pdf2image import convert_from_path
from page import Page
from config import OUTPUT_PATH


class PDFDoc:
    """
    PDFDoc Class

    path: path to PDF file.
    pages: collection of Page objects.
    """

    def __init__(self, path, filename):
        self.filename = filename
        self._filename_split = filename.rsplit('.', 1)
        self.path = path
        self.pages = self.extract_pages()

    def extract_pages(self):
        return [Page(p) for p in convert_from_path(self.path)]

    def output_pages(self, compress=False, build_path=None):
        if not build_path:
            build_path = OUTPUT_PATH + self.filename

        if os.path.exists(build_path):
            shutil.rmtree(build_path)

        os.mkdir(build_path)

        for i, page in enumerate(self.pages):
            page.imgData.save(build_path + f"/{i:03}" + ".jpg")

        if compress:
            shutil.make_archive(
                OUTPUT_PATH + self._filename_split[0],
                'zip',
                build_path
            )
            shutil.rmtree(build_path)

    def __getitem__(self, index):
        return self.pages[index]

    def __repr__(self):
        return ''
