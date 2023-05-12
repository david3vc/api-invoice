using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using Domain;
using Infraestructure.Repositories.Abstractions;
using Infraestructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(IMapper mapper, ISubjectRepository subjectRepository)
        {
            _mapper = mapper;
            _subjectRepository = subjectRepository;
        }

        public async Task<SubjectDto> Create(SubjectFormDto dto)
        {
            var entity = _mapper.Map<Subject>(dto);
            var response = await _subjectRepository.Create(entity);

            return _mapper.Map<SubjectDto>(response);
        }

        public async Task<SubjectDto?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SubjectDto?> Find(int id)
        {
            var response = await _subjectRepository.Find(id);

            return _mapper.Map<SubjectDto>(response);
        }

        public async Task<IList<SubjectDto>> FindAll()
        {
            var response = await _subjectRepository.FindAll();

            return _mapper.Map<IList<SubjectDto>>(response);
        }

        public async Task<SubjectDto?> Update(SubjectDto dto)
        {
            var entity = _mapper.Map<Subject>(dto);
            var response = await _subjectRepository.Update(entity);

            return _mapper.Map<SubjectDto>(response);
        }
    }
}
