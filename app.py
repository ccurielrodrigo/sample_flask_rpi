# Imports
from flask import Flask, request, jsonify

# Define the app
app = Flask(__name__)

# Endpoints
@app.route('/')
def index():
    return "We made it!"

@app.route('/post', methods=['POST'])
def post():
    data_to_return = request.form.get('message')
    return message

# Runtime configuration
if __name__ == '__main__':
    app.run(debug=True, port=5000, host='0.0.0.0')
