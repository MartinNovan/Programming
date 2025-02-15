# Old code with repetition
# sum = 0
# sum += values[0] * weights[0]
# sum += values[1] * weights[1]
# sum += values[2] * weights[2]
# sum += values[3] * weights[3]
# sum += values[4] * weights[4]
# sum += values[5] * weights[5]

# New code without repetition
weighted_sum = sum(value * weight for value, weight in zip(values, weights))
print("Weighted sum:", weighted_sum)