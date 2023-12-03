const api_endPoint = 'http://localhost:5022';

export const getCampaingnById = async (id) => {
    try {
        console.log('ID recebido na API:', id);

        const response = await fetch(`${api_endPoint}/api/CampaingnDonation/${id}`);
        console.log('API Response:', response);

        if (response.ok) {
            const data = await response.json();
            console.log('API Data:', data);

            if (data && data.data) {
                return data.data;
            } else {
                throw new Error('Formato de resposta inválido');
            }
        } else {
            throw new Error('Erro ao obter os dados');
        }
    } catch (error) {
        console.error('Erro na requisição: ', error);
        throw new Error('Erro na requisição: ' + error.message);
    }
};
