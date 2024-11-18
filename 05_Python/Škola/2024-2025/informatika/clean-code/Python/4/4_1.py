total_score = 0

def add_score(points):
    global total_score
    total_score += points
    print("Total score is now:", total_score)

add_score(10)
add_score(20)
