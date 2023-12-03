export const createDataUser = (FormData) => {
    const user = {
        name: FormData.name,
        surname: FormData.surname,
        phoneNumber: FormData.phoneNumber,
        CPF: FormData.CPF,
        birthdate: FormData.birthdate,
        email: FormData.email,
        passwordHash: FormData.passwordHash,
        profileAcess: 1,
        addressViewModels: [
            {
                street: FormData.street,
                houseNumber: FormData.houseNumber,
                neighborhood: FormData.neighborhood,
                complement: FormData.complement,
                zipCode: FormData.zipCode,
                city: FormData.city
            }

        ]
    };

    return user
}