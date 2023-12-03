const api_endPoint = 'http://localhost:5022';

export const getVolunteeringById = async (id) => {
    try {
        const response = await fetch(`${api_endPoint}/api/volunteering/${id}`);
        console.log('API Response:', response);

        if (response.ok) {
            const data = await response.json();
            console.log('API Data:', data);

            if (data && data.data) {
                return data.data; // Retorna diretamente o objeto de detalhes do voluntariado
            } else {
                throw new Error('Formato de resposta inválido');
            }
        } else {
            throw new Error('Erro ao obter os dados');
        }
    } catch (error) {
        throw new Error('Erro na requisição: ' + error.message);
    }
};
