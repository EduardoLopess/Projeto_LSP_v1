const api_endPoint = 'http://localhost:5022';

export const getCampaignDonation = async () => {
    try {
        const response = await fetch(`${api_endPoint}/api/CampaingnDonation`);
        if (response.ok) {
            const data = await response.json();
            // Verifica se a resposta contém a chave "data" e se "data" é um array
            if (data && Array.isArray(data.data)) {
                return data.data; // Retorna o array de voluntariados
            } else {
                throw new Error('Formato de resposta inválido');
            }
        } else {
            throw new Error('Erro ao obter os dados');
        }
    } catch (error) {
        throw new Error('Erro na requisição: ' + error.message);
    }
}