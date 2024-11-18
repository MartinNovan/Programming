def divide(a,b):
    if b!=0:
        return a/b
    else:
        print("Division by zero.")
        return None

result=divide(10,2)
print("Result:"+str(result))
