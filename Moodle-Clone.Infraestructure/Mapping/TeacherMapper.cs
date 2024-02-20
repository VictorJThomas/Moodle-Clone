using Moodle_Clone.Domain.DTOs;
using Moodle_Clone.Domain.Models;
using Riok.Mapperly.Abstractions;
using static Moodle_Clone.Domain.DTOs.TeacherDTO;

namespace Moodle_Clone.Infraestructure.Mapping
{
    [Mapper]
    public partial class TeacherMapper
    {
        public Assignments MapAssigments(PublishAssigmentDTO publishAssigmentDTO)
        {
            var mapper = AssigmentsToTeacher(publishAssigmentDTO);
            return mapper;
        }

        public partial Assignments AssigmentsToTeacher(PublishAssigmentDTO assigment);
        public PublishAssigmentDTO MapPublishAssignment(Assignments assignments) => TeacherToPublishAssignmentDTO(assignments);

        [MapProperty(nameof(Assignments.AssignmentsId), nameof(PublishAssigmentDTO.AssignmentsId))]
        [MapProperty(nameof(Assignments.TeacherId), nameof(PublishAssigmentDTO.AssignmentsId))]
        [MapProperty(nameof(Assignments.AssignmentsName), nameof(PublishAssigmentDTO.AssignmentsName))]
        [MapProperty(nameof(Assignments.AssignmentsDescription), nameof(PublishAssigmentDTO.AssignmentsDescription))]
        [MapProperty(nameof(Assignments.LimitDate), nameof(PublishAssigmentDTO.LimitDate))]

        [MapProperty(nameof(PublishAssigmentDTO.AssignmentsId), nameof(Assignments.AssignmentsId))]
        [MapProperty(nameof(PublishAssigmentDTO.TeacherId), nameof(Assignments.TeacherId))]
        [MapProperty(nameof(PublishAssigmentDTO.AssignmentsName), nameof(Assignments.AssignmentsName))]
        [MapProperty(nameof(PublishAssigmentDTO.AssignmentsDescription), nameof(Assignments.AssignmentsDescription))]
        [MapProperty(nameof(PublishAssigmentDTO.LimitDate), nameof(Assignments.LimitDate))]


        private partial PublishAssigmentDTO TeacherToPublishAssignmentDTO(Assignments assignments);

    }
}
