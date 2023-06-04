"""
MyDoc Scanner

__init__.py

Main flask server definition.

Author: Paul McAvoy & Nikola Apostolov
Date Updated: 04/06/2023
"""

from flask import Flask, request

serve = Flask("MyDoc Scanner - Server")


@serve.get('/api/')
def active():
    return {'active': True}


@serve.post('/api/pdfupload')
def pdf_upload():
    data = request.json["fileData"]
    data.encode('latin-1')
    with open("B:\\git-workspace\\my-doc-scanner\\uploads\\pdf\\test.pdf", "bw") as file:
        file.write(data)
    return {"uploaded": True}


if __name__ == '__main__':
    serve.run()
