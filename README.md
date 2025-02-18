# Codice Fiscale Generator

Welcome to the **Codice Fiscale Generator** repository! 

🎯 This project is a simple yet powerful application that calculates the **Codice Fiscale**, an Italian tax code used for personal identification.

## 🚀 Features
- ✅ Generate a **Codice Fiscale** based on personal details (name, surname, birth date, gender, birthplace).
- 🔍 Validate an existing **Codice Fiscale**.
- 📂 Support for common edge cases and exceptions.

![image](https://github.com/user-attachments/assets/5190f791-2a3b-4d9c-88cc-3abd38f5a523)

## 🛠️ How It Works
The application follows the official rules for generating and validating an Italian **Codice Fiscale**, including:
1. Encoding **surname and name** using consonants and vowels.
2. Extracting **date of birth and gender** in the correct format.
3. Determining the **municipality code** using data contained in `listcomuni.txt`.
4. Computing the **check character** to ensure validity.

## 📁 Repository Structure
- **src/** - Source code for the application.
- **tests/** - Unit tests to validate functionality.
- **docs/** - Additional documentation.
- **README.md** - This file.

## 🎯 Usage
You can run the application using any C# IDE if you have a recent .NET framework installed.

---
Feel free to explore, contribute, or suggest improvements! 🚀
