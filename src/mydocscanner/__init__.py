"""
MyDoc Scanner Server

__init__.py

Main RestAPI Server

Author: Paul McAvoy & Nikola Apostolov
Date Updated: 04/06/2023
"""

from flask import Flask, request, jsonify
from werkzeug.utils import secure_filename
import uuid

serve = Flask("MyDoc Scanner Server")
ROOT = '../../'
UPLOAD_PATH = ROOT + 'uploads/pdf/'


@serve.get("/")
def active():
    """
    Simple API activity response.
    :return: JSON Object - {
                'active': Always true when the API is active.
             }
    """
    return {"active": True}, 200


@serve.post("/pdfupload")
def accept_PDF_upload():
    """
    Uploads a pdf document onto the server with a secure filename.

    :return: JSON Object - {
                'uploaded': boolean indicating if the document correctly uploaded,
                'error': set to error if uploading errors out. unset if uploading succeeds,
                'filename': set to the uploaded filename if the uploading succeeds
             }
    """
    def generate_filedata(fname):
        """
        Generate a unique secure filename for the uploaded file data and extract the file extension for the document.

        :param fname: initial filename of uploaded document.
        :return: (generated filename, filetype as extension)
        """
        fData = secure_filename(fname)
        fDataSplit = fData.rsplit('.', 1)
        return fDataSplit[0] + '-' + str(uuid.uuid4()) + '.' + fDataSplit[1], fDataSplit[1]
    error = None

    if 'file' not in request.files:
        error = "No file added to be uploaded."

    file = request.files['file']
    filename, filetype = generate_filedata(file.filename)

    if filename == '' or \
            '.' not in filename or \
            filetype != 'pdf':
        error = "Invalid file selection."

    if error:
        return {'uploaded': False, 'error': error}, 400

    file.save(UPLOAD_PATH + filename)
    return {'uploaded': True, 'filename': f"{filename}"}, 200


if __name__ == '__main__':
    serve.run(debug=True)


