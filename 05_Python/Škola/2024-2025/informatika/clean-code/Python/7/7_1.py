def calculate_average (numbers):
    total=0
    for i in range(len(numbers)):
        total+=numbers[i]
    average=total/len(numbers)
    return average

scores=[80,90,100]
avg_score=calculate_average(scores)
print("Average Score:",avg_score)
