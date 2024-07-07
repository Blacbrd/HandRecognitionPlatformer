import cv2 as cv
import time
import mediapipe as mp



def getLetter():
        
    # User's capture device
    cap = cv.VideoCapture(0, cv.CAP_DSHOW)

    # Maps out landmarks on hand, only allows one hand to be analysed at once
    mpHands = mp.solutions.hands
    hands = mpHands.Hands(False, 1)
        
    fingerCoordinates = [(8, 6), (12, 10), (16, 14), (20, 18)]

    prev_time = 0
    current_time = 0

    finish = False
    while finish == False:

        success, img = cap.read()

        imgRGB = cv.cvtColor(img, cv.COLOR_BGR2RGB)
        results = hands.process(imgRGB)

        # Puts landmarks on the hands
        if results.multi_hand_landmarks:
            handPoints = []
            for handLms in results.multi_hand_landmarks:

                # This for loop shows where the landmarks are on the screen
                # ID is which landmark it is, land_mark is where it is on the screen
                # HandPoints list stores coordinates to later check how many fingers the user is holding up
                    
                for id, land_mark in enumerate(handLms.landmark):
                    height, width, channel = img.shape
                    centreX, centreY = int(land_mark.x * width), int(land_mark.y * height)
                    #print(id,":", centreX, centreY)
                    handPoints.append((centreX, centreY))

            # Counts how many fingers are held up
            fingerCount = 0
            for coordinate in fingerCoordinates:
                if handPoints[coordinate[0]][1] < handPoints[coordinate[1]][1]:
                    fingerCount += 1
                
            if fingerCount == 0:
                print("Fire Ball")
                finish = True
                cv.destroyAllWindows()
                return "J"
            if fingerCount == 1:
                print("Lightning Bolt")
                finish = True
                cv.destroyAllWindows()
                return "K"
            if fingerCount == 4:
                print("Water Fall")
                finish = True
                cv.destroyAllWindows()
                return "L"

        current_time = time.time()
        fps = 1/(current_time - prev_time)
        prev_time = current_time
        #cv.putText(img, str(int((fps))), (10,50), cv.FONT_ITALIC, 1, (255, 0, 0),3)


        # Puts the camera in the correct place and displays name    
        cv.imshow("Cast your spell!", img)
        cv.moveWindow("Cast your spell!" , 0, 890)
        key = cv.waitKey(1)

            
            
        # if "f" key is pressed, the program ends
        if key == ord("f"):
            finish = True
            cv.destroyAllWindows()
            cap.release()
            return "Q"

