export interface ShortStatusDto {
    id: number;
    status: string;
}

export interface ShortCategoriaDto {
    id: number;
    categoria: string;
}

export interface TarefaDto {
    id: number;
    comentario: string;
    status: ShortStatusDto;
    categoria: ShortCategoriaDto;
}