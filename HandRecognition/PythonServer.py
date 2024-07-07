import socket
import HandRecognition

class Server():
    
    def __init__(self):
        
        # Sets up the port and IP address
        hostname = socket.gethostname()
        ipAddress = socket.gethostbyname(hostname)
        port = 5050
        data = HandRecognition.getLetter()
        print(data)

        # Starts the connection with the C# server
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

        sock.connect((ipAddress, port))
        sock.sendall(data.encode("utf-8"))
        sock.close()

Server()