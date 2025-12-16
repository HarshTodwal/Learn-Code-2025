def calculate_armstrong_sum(number):
    # Initializing Sum and Number of Digits
    digit_count = 0
    armstrong_sum = 0

    # Calculating Number of individual digits
    temp_number = number
    while temp_number > 0:
        digit_count += 1
        temp_number //= 10

    # Finding Armstrong Number
    temp_number = number
    while temp_number > 0:
        digit = temp_number % 10
        armstrong_sum += digit ** digit_count
        temp_number //= 10

    return armstrong_sum

# End of Function

# User Input
input_number = int(input("Please enter the number to check for Armstrong: "))

if input_number == calculate_armstrong_sum(input_number):
    print(f"{input_number} is an Armstrong Number.")
else:
    print(f"{input_number} is NOT an Armstrong Number.")
