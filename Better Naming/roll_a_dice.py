import random

def roll_dice(max_value):
    return random.randint(1, max_value)

def main():
    dice_sides = 6
    is_running = True

    while is_running:
        user_input = input("Ready to roll? Enter Q to Quit: ")

        if user_input.lower() != "q":
            rolled_number = roll_dice(dice_sides)
            print("You have rolled a", rolled_number)
        else:
            is_running = False