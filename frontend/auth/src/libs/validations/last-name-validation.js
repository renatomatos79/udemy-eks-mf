export const validateLastName = (value) => {
    if (!value) return "Last name is required";
    if (value.length < 3 || value.length >= 30) return "Last name should contain 3 to 30 characters";
    return "";
};

