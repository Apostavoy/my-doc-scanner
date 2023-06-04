"""
MyDoc Scanner Server

pageText.py

{Desc}

Author: Paul McAvoy & Nikola Apostolov
Date Updated: 04/06/2023
"""

import re

class PageText:
    """
    Page Class

    textdata: string
    """
    def __init__(self, textData):
        self.textData = textData

    def evaliate(self, regex):
        return str(re.match(regex, self.textData)) != 'None'