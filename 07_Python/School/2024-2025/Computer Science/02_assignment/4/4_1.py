# Old code with side effects
# total_score = 0
# def add_score(points):
#     global total_score
#     total_score += points
#     print("Total score is now:", total_score)

# New code without side effects
def add_score(current_score, points):
    new_score = current_score + points
    print("Total score is now:", new_score)
    return new_score

total_score = 0
total_score = add_score(total_score, 10)
total_score = add_score(total_score, 20)