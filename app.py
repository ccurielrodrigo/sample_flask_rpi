# Imports
from flask import Flask

# Define the app
app = Flask(__name__)

# Endpoints
@app.route('/')
def index():
    return "We made it!";

# Runtime configuration
if __name__ == '__main__':
    app.run(debug=True, port=5000, host='0.0.0.0')
